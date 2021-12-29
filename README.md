# encryption
## _An attempt to create an ecryption service_

[![N|Solid](https://cldup.com/dTxpPi9lDf.thumb.png)](https://nodesource.com/products/nsolid)

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

#### An example of Public Key:
```sh
-----BEGIN PUBLIC KEY-----
MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQC7pbDRvuqRL0EsKjYGqPZWu4VF
KI1iilisb3+yW5guIP4I+T8qhP8dcUugiwa2fDwGgl3Y+PHASGdCfvYOfMefWlNU
oGeLv4Tx6nqvq2OcVzRhYjUfIpRE7z81xhmKtvxxLTNzTAoHN6rWqarKYMFydR/s
D+oJs7LnnJoWieh1QQIDAQAB
-----END PUBLIC KEY-----
```


#### An example of Private Key:
```sh
-----BEGIN RSA PRIVATE KEY-----
MIICXAIBAAKBgQC7pbDRvuqRL0EsKjYGqPZWu4VFKI1iilisb3+yW5guIP4I+T8q
hP8dcUugiwa2fDwGgl3Y+PHASGdCfvYOfMefWlNUoGeLv4Tx6nqvq2OcVzRhYjUf
IpRE7z81xhmKtvxxLTNzTAoHN6rWqarKYMFydR/sD+oJs7LnnJoWieh1QQIDAQAB
AoGAPeQ4nfXKiHh9loOVrjysg472NglaGNZoyPc9tyZe21gmce9D1lJnkt57g0hX
vnjbk4oMSjRSCInZBSW7IqwlauiYwJra5O7MbLFaCTWDDnwFB+Zcz9E2PbPdFQFl
jyYfh0gm9zvo79oyqESXtfYaMfx45zPbJGOkhiPcjZDsZcECQQDyy2qz6L6JALIY
L1CtY6NTSm33rXv6Y+RzTBZovkK9OvMODvklsOhbcNQx0o7vQ5600dbHORwteCcm
cHMgFDGnAkEAxdpsD2omWPzRYCRmk72aqRtccp9AE9eE75mUG6sMt3NDqwGeTuWV
EH70XC3yIwqFmkc3zzNjZqsxTEDtuRtu1wJBAJoAHpko2poJv+0JLfIczf7JqgC8
oHPMop3jOB+N9sUSPBLBupSGpotBgMZtWM44pNTqeIH7Hn1UxfhiwRMq2+cCQDwZ
K8fG450WNncwt2PbLRZ+9CbxDqK4TW4GRYHeBD/ZKE3ScQbgH9Zh6dHyNuHD+W8y
gNZUcrYl/BSAiHU4ywMCQDok1QgvVmc8jma9qK2dxmd4IR8varRPti4VQAMumdaE
4s1Ofdw+8Bl2FATkdQZDLUQbWat4E5l8uGLfYZAHSow=
-----END RSA PRIVATE KEY-----
```

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
