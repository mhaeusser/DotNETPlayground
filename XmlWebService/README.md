# XmlWebService
Endpoints:

* http://localhost:5134/health GET, works in browser
* http://localhost:5134/xml POST, use Postman or so or:

```shell
curl --location 'http://localhost:5134/xml' \
--header 'Content-Type: application/xml' \
--data '<xml>123</xml>'
```

