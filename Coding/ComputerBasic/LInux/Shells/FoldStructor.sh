#!/bin/usr/bash
fileName=file.txt
if [ !-f $fileName ]; then
    echo "$fileName is not a file"
    exit
fi

for directoryPath in `cat $fileName`
do 
    mkdir -p $directoryPath
done