# Stage 1: Build - Dùng SDK để biên dịch
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 1. Sao chép các file cần thiết (Chạy từ Solution Root)
# Copy Solution file
COPY ThangLong.SinhVien.sln .
# Copy tất cả các file .csproj (Loại bỏ vì chúng ta sẽ copy toàn bộ source ở bước sau)
# COPY */*.csproj ./  <-- Đã xóa

# 2. Khôi phục các gói NuGet (NuGet Restore)
# SAO CHÉP TOÀN BỘ MÃ NGUỒN ĐỂ GIỮ NGUYÊN CẤU TRÚC THƯ MỤC
COPY . .

# Chạy restore trên Solution file để đảm bảo tất cả các tham chiếu được giải quyết
# Lệnh này bây giờ sẽ hoạt động vì tất cả các thư mục project đã có trong /src
RUN dotnet restore ThangLong.SinhVien.sln

# 3. Sao chép toàn bộ mã nguồn còn lại (Đã thực hiện ở bước 2)

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