#

## docker

### build

```ps1

docker build -t <your docker hub id>/platformservice .

# Exmaple
docker build -t arisuokay/platformservice .

```

### push

```ps1

docker push <your docker hub id>/platformservice

# Exmaple
docker push arisuokay/platformservice

```

### container

```ps1
# run
docker run -p 8080:80 --name platformservice-container -d arisuokay/platformservice

# list
docker ps

# stop
docker stop platformservice-container

#remove
docker rm platformservice-container

```
