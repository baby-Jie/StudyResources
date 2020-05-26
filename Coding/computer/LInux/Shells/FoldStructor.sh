#!/bin/usr/bash
fileName=file.txt
if [ $# -eq 0 ];then
    echo "length is 0"
    exit
fi

if [ !-f $fileName ]; then
    echo "$fileName is not a file"
    exit
fi

for directoryPath in `cat $fileName`
do 
    if [ $]
    mkdir -p $directoryPath
done