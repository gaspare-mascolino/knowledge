#! /bin/sh

fileName="wget.out"

wget -o "${fileName}" --spider -e robots=off -r -p -l 3 -e no_proxy=localhost "$1"
not200s=`cat ${fileName} | grep "awaiting response" | grep -c -v 200`

if [ ${not200s} -gt 0 ]; then
  echo "Found ${not200s} not 200 response code navigating $1 website! Check the ${fileName} file." && exit 1
fi

#rm -rf "${fileName}"
echo "Everything looks fine!"
