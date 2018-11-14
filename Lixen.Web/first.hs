doubleMe x = x + x

doubleUs x y = doubleMe x + doubleMe y

doubleSmallNumber x = if x > 100 then x else x * 2

addThree :: Int -> Int -> Int -> Int
addThree a b c = a + b + c

removeNonUppercase :: String -> String
removeNonUppercase st = [a | a <- st, a `elem` ['A'..'Z']]

circumference :: Float -> Float
circumference r = 2 * pi * r

circumference' :: Double -> Double
circumference' r = 2 * pi * r

factorial :: (Integral a) => a -> a
factorial n = product [1..n]

factorial' :: Integer -> Integer
factorial' n = product [1..n]

factorial'' :: (Integral a) => a -> a
factorial'' 0 = 1
factorial'' n = n * factorial (n - 1)

power :: (Integral a) => a -> a
power 0 = 1
power n = 2 * power (n - 1)

addListOfNumericTuples :: (Num t) => [(t, t)] -> [t]
addListOfNumericTuples list = [a + b | (a,b) <- list]

length' :: (Num b) => [a] -> b
length' [] = 0
length' (_:xs) = 1 + length' xs

sum' :: (Num a) => [a] -> a
sum' [] = 0
sum' (x:xs) = x + sum' xs

fibo :: (Integral a) => a -> a
fibo 0 = 0
fibo 1 = 1
fibo n = fibo (n - 1) + fibo (n - 2)

replicate' :: (Num i, Ord i) => i -> a -> [a]
replicate' n x
   | n <= 0 = []
   | otherwise = x:replicate' (n - 1) x

take' :: (Num i, Ord i) => i -> [a] -> [a]
take' n _
   | n <= 0 = []
take' _ [] = []
take' n (x:xs) = x:take' (n-1) xs

reverse' :: [a] -> [a]
reverse' [] = []
reverse' (x:xs) = reverse' xs ++ [x]

repeat' :: a -> [a]
repeat' x = x:repeat' x

zip' :: [a] -> [b] -> [(a,b)]
zip' _ [] = []
zip' [] _ = []
zip' (x:xs) (y:ys) = (x,y):zip' xs ys

elem' :: (Eq a) => a -> [a] -> Bool
elem' _ [] = False
elem' x (y:ys) 
    | x == y    = True
    | otherwise = elem' x ys

-- quicksort :: (Ord a) => [a] -> [a]
-- quicksort [] = []

applyTwice :: (a -> a) -> a -> a
applyTwice f x = f (f x)

zipWith' :: (a -> b -> c) -> [a] -> [b] -> [c]
zipWith' _ [] _ = []
zipWith' _ _ [] = []
zipWith' f (x:xs) (y:ys) = f x y : zipWith' f xs ys
