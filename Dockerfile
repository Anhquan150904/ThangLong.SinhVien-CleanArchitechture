# Stage 1: Build - Dùng SDK để biên dịch
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 1. Sao chép các file cần thiết (Chạy từ Solution Root)
# Copy Solution file
COPY ThangLong.SinhVien.sln .
# Copy tất cả các file .csproj
COPY */*.csproj ./

# 2. Khôi phục các gói NuGet (NuGet Restore)
# Chạy restore trên Solution file để đảm bảo tất cả các tham chiếu được giải quyết
RUN dotnet restore ThangLong.SinhVien.sln

# 3. Sao chép toàn bộ mã nguồn còn lại
COPY . .

# 4. Xuất bản (Publish)
# Chuyển đổi thư mục làm việc sang thư mục của project API
WORKDIR /src/ThangLong.WebApi
# Chạy publish.
RUN dotnet publish -c Release -o /app/out

# Stage 2: Runtime - Dùng Runtime image nhỏ gọn để chạy ứng dụng
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Sao chép kết quả đã publish từ Stage 1
COPY --from=build /app/out .

# Thiết lập cổng và lệnh chạy
EXPOSE 80
ENTRYPOINT ["dotnet", "ThangLong.WebApi.dll"]