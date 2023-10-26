FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /app
COPY . .
RUN dotnet restore 
RUN dotnet publish customerApi.csproj -c Release -o out
WORKDIR out
ENV ASPNETCORE_URLS="http://*:5000"
ENTRYPOINT ["dotnet", "customerApi.dll"]