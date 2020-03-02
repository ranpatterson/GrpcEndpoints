# Sharing gRPC ProtoBuff contracts using an endpoint


gRPC services require a service contract usually defined using the Protocol Buffer Language in proto files. The service contract is then used to generate your C# (or language of your choice) server side classes and your client side proxies. Sharing these proto contract files is necessary for generating these classes. However, there is no easy way to share these files other than copying them from the server to the client. Sharing files like this can be especially difficult in a Microservices architecture where there can be many different clients developed by many different teams. This repository shows how to setup the ASP.NET Core middleware to add your ProtoBuf files and an endpoint.

