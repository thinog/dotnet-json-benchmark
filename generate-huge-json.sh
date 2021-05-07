#!/bin/bash

json_total=1000000
json_step=10000

echo "Creating an array with $json_total JSONs"
echo -n "" > dataset.json

json="["

for i in $(seq 1 $json_total)
do
    json="$json{\"id\":$i,\"name\":\"test-$i\"},"
    echo -ne "\r$i"

    if [ $(($i % $json_step)) -eq 0 ]
    then
        echo -ne $json >> dataset.json
        json=""
    fi
done

echo -ne "$json]" >> dataset.json

sed -i 's/,]$/\n]/' dataset.json
sed -i 's/{/\n\t{/g' dataset.json