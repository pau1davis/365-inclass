using System;
// Write your Adder class here
class Adder : I365, IComparable {
    public float LeftValue {
        get {
            return left;
        }
        set {
            left = value; 
        }
    }
    private float left;
    private float right;
    public float RightValue {
        get {
            return right;
        }
        set {
            right = value;
        }
    }
    public float Operator() {
        return left + right;
    }
    
    public int CompareTo(object? rhs) {
        if (rhs == null) {
            return 1;
        }
        I365 other = (I365) rhs;

        return this.Operator().CompareTo(other.Operator());
    }

    public Adder(float leftvalue, float rightvalue) {
        left = leftvalue;
        right = rightvalue;

        //return Operator(LeftValue, RightValue);
    }
}

// Write your Subber class here
class Subber : I365, IComparable {
    public float LeftValue {
        get {
            return left;
        }
        set {
            left = value; 
        }
    }
    private float left;
    private float right;
    public float RightValue {
        get {
            return right;
        }
        set {
            right = value;
        }
    }
    public float Operator() {
        return left - right;
    }

    public int CompareTo(object? rhs) {
        if (rhs == null) {
            return 1;
        }
        I365 other = (I365) rhs;

        return this.Operator().CompareTo(other.Operator());
    }

    public Subber(float leftvalue, float rightvalue) {
        left = leftvalue;
        right = rightvalue;

        //return Operator(LeftValue, RightValue);
    }
}