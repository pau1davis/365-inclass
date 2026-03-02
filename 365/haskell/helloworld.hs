import System.IO (hFlush, stdout)

sayHelloTo :: String -> IO ()
sayHelloTo n = putStrLn $ "Hello, " ++ n ++ "!"

askForName :: IO ()
askForName = do
    putStr "What is your name? "
    hFlush stdout

main :: IO ()
main = askForName >> getLine >>= sayHelloTo