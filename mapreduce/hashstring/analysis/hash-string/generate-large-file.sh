#!/bin/bash
ruby -e 'a=STDIN.readlines;1000000.times do;print a[rand(a.size)].chomp end' < /usr/share/dict/words > big1.txt
tail -c 100000 big1.txt > pattern.txt
cp big1.txt big2.txt
cp big1.txt big3.txt
cp big1.txt big4.txt
cat big1.txt big2.txt big3.txt big4.txt > big.txt
rm big1.txt
rm big2.txt
rm big3.txt
rm big4.txt
