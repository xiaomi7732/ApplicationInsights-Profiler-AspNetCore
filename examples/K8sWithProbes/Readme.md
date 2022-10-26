# Application Insights Profiler Example

For application running inside Kubernetes with Readiness / Liveness probe on.

## Build container

* Define variables

```shell
$registry_account='your_container_registry_account'
$image_name='ai-profiler-k8s-probes'
```

* Build the container

```shell
docker build -t $image_name .
```

* When it is ready

```shell
docker tag $image_name $registry_account/$image_name
docker push $registry_account/$image_name
```