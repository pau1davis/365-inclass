use std::io::{self, prelude::*};
struct Operation {
    pub op: char, // +, -, *, or /
    pub left: f32,
    pub right: f32,
}
impl Operation {
    pub const fn new(op: char, left: f32, right: f32) -> Self {
        // TODO: Fix op so that x's are turned into *'s
        let op = if op == 'x' { '*' } else { op };
        Self {
            op,
            left,
            right
        }
    }
    pub fn result(&self) -> f32 {
        // TODO: calculate the result of left <op> right
        // A match statement will make your life easy here.
        match self.op {
            '+' => self.left + self.right,
            '-' => self.left - self.right,
            '*' => self.left * self.right,
            '/' => self.left / self.right,
            _ => f32::NAN,
        }
    }
}

// HERE IS YOUR MAIN()
fn main() {
    let ipt = io::stdin();
    let mut s = String::with_capacity(20);
    let mut operations: Vec<Operation> = vec![];

    loop {
        s.clear();
        ipt.read_line(&mut s).expect("Unable to read line");
        if s == "" {
            break;
        }
        // TODO: Write your input handling code here.
        let trimmed = s.trim();
        if trimmed.is_empty() {
            break;
        }

        let parts: Vec<&str> = trimmed.split_whitespace().collect();
        if parts.len() != 3 {
            continue;
        }

        let left = match parts[0].parse::<f32>() {
            Ok(v) => v,
            Err(_) => continue,
        };
        let op = match parts[1].chars().next() {
            Some(c) => c,
            None => continue,
        };
        let right = match parts[2].parse::<f32>() {
            Ok(v) => v,
            Err(_) => continue,
        };

        operations.push(Operation::new(op, left, right));
    }
    // TODO: Sort. You can use the .sort_by() function of Vec with the sorting_func below
    operations.sort_by(|l, r| sorting_func(l.op, r.op));
    
    // TODO: Write your output code here.
    for operation in &operations {
        println!(
            "{:.2} {} {:.2} = {:.2}",
            operation.left,
            operation.op,
            operation.right,
            operation.result()
        );
    }

}
// TODO: You will need a sort function here to sort the vector
fn sorting_func(opL: char, opR: char) -> std::cmp::Ordering {
    // std::cmp::Ordering is an enumeration with three elements:
    // Less, Equal, and Greater for less-than, equal-to, and greater-than
    // respectively. These are equivalent to memcmp/strcmp in C with
    // Less = -1, Equal = 0, and Greater = 1
    fn rank(op: char) -> i32 {
        match op {
            '*' => 0,
            '/' => 1,
            '+' => 2,
            '-' => 3,
            _ => 4,
        }
    }

    rank(opL).cmp(&rank(opR))
}