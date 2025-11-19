# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Sao chép file Webapi.csproj và chạy restore trên file đó
COPY ThangLong.WebApi/ThangLong.WebApi.csproj ThangLong.WebApi/
RUN dotnet restore ThangLong.WebApi/ThangLong.WebApi.csproj

# Sao chép toàn bộ source code (bao gồm cả các project khác)
COPY . .
WORKDIR /src/ThangLong.WebApi 
RUN dotnet publish -c Release -o /app/out 

# Stage 2: Runtime (Giữ nguyên)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

EXPOSE 80
ENTRYPOINT ["dotnet", "ThangLong.WebApi.dll"]