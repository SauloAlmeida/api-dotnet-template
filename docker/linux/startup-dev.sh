# 💡run it in root folder
docker build --rm -t api-dotnet-template src/

docker run  --rm -p 5000:5000 -p 5001:5001 \
            -e ASPNETCORE_HTTP_PORT=https://+:5001 \
            -e ASPNETCORE_URLS=http://+:5000 \
            -e ASPNETCORE_ENVIRONMENT=Development \
            api-dotnet-template
