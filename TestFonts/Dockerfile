FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build

WORKDIR /src
COPY ["TestFonts/TestFonts.csproj", "TestFonts/"]
RUN dotnet restore "TestFonts/TestFonts.csproj"
COPY . .
WORKDIR "/src/TestFonts"
RUN dotnet build "TestFonts.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestFonts.csproj" -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine
WORKDIR /app
COPY --from=publish /app/publish .

RUN apk add libgdiplus --no-cache --repository http://dl-3.alpinelinux.org/alpine/edge/testing/ --allow-untrusted

RUN apk --no-cache add msttcorefonts-installer fontconfig && \
    update-ms-fonts && \
    fc-cache -f

ENTRYPOINT [ "dotnet", "TestFonts.dll" ]