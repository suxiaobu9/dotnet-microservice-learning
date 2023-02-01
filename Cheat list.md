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

## kubernetes

### apply

```ps1

kubectl apply -f platforms-depl.yaml

```

### get

```ps1

kubectl get deployments

kubectl get pods

kubectl get services

```

### delete

```ps1

kubectl delete deployment platforms-depl

kubectl get pods

kubectl get services

```
