# Stage 1: Build - Dùng SDK để biên dịch
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 1. Sao chép các file cần thiết (SỬ DỤNG CÚ PHÁP THƯ MỤC CHA: ..)
# - Copy Solution file
# Lệnh này tìm ThangLong.SinhVien.sln ở cấp độ thư mục cha
COPY ../ThangLong.SinhVien.sln . 
# - Copy tất cả các file .csproj (phải bao gồm thư mục WebApi hiện tại)
# Sử dụng ../*/*.csproj để lấy tất cả csproj từ các thư mục ngang hàng.
# Tuy nhiên, cách an toàn nhất là sao chép toàn bộ context sau đó mới publish.

# TẠM THỜI bỏ qua .csproj vì có thể phức tạp đường dẫn. 
# CHỈ CẦN COPY Solution và RESTORE, sau đó COPY toàn bộ source.
# ---------------------------------------------------------------
# COPY *.csproj ./  <-- Loại bỏ, không cần thiết cho restore trên solution

# 2. Khôi phục các gói NuGet (NuGet Restore)
# Chạy restore trên Solution file đã copy
RUN dotnet restore ThangLong.SinhVien.sln

# 3. Sao chép toàn bộ mã nguồn còn lại (TỪ THƯ MỤC CHA)
# Lệnh COPY .. . sẽ sao chép toàn bộ source code (kể cả các project khác) vào /src
COPY .. .

# 4. Xuất bản (Publish)
# Thay đổi thư mục làm việc sang thư mục của project API
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