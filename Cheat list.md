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

### restart

```ps1

kubectl rollout restart deployment platforms-depl

```

### get

```ps1

kubectl get deployments

kubectl get pods

kubectl get services

kubectl get storageclass

kubectl get pvc

# with namespace

kubectl get deployments --namespace=ingress-nginx

kubectl get pods --namespace=ingress-nginx

kubectl get services --namespace=ingress-nginx

```

### delete

```ps1

kubectl delete deployment platforms-depl

kubectl get pods

kubectl get services

```

### create secret

```ps1

kubectl create secret generic mssql --from-literal=SA_PASSWORD="passw0rd!"

```

### Ingress nginx

[Ingress nginx](https://kubernetes.github.io/ingress-nginx/deploy/)

```ps1
kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.5.1/deploy/static/provider/cloud/deploy.yaml
```

### mssql pvc path

> \\wsl.localhost\docker-desktop-data\data\k8s-pvs\mssql-claim\pvc-87dc177c-249e-4158-bc53-a46f463e00e7

## dotnet

### migration

```ps1

# install global ef tool
dotnet tool install --global dotnet-ef

# initial migration
dotnet ef migrations add initialmigration

```

## Other

- map `acme.com` to 127.0.0.1
  > 開啟路徑 `C:\Windows\System32\drivers\etc\hosts` 的檔案後，加入一行 `127.0.0.1 acme.com`，需要有管理員權限
