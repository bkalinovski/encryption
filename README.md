# encryption
## _An attempt to create an ecryption service_

[![N|Solid](https://cldup.com/dTxpPi9lDf.thumb.png)](https://nodesource.com/products/nsolid)

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

## Key generation

To generate public & private keys use the following commands.
Private Key:
```sh
openssl genrsa -out rsa-private.txt 1024
```

Public Key from Private Key:
```sh
openssl rsa -in .\rsa-private.txt -out rsa-public.txt -pubout -outform PEM
```
