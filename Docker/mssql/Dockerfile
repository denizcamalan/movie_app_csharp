FROM mcr.microsoft.com/mssql/server:2017-latest

ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=reallyStrongPwd123

COPY . /var/opt/movie_app_csharp

RUN apt-get update \
    && apt-get install unzip dotnet-sdk-2.2 -y --no-install-recommends \
    && wget -q -O /var/opt/sqlpackage.zip https://go.microsoft.com/fwlink/?linkid=2069122 \
    && unzip -qq /var/opt/sqlpackage.zip -d /var/opt/sqlpackage \
    && rm /var/opt/sqlpackage.zip \
    && chmod +x /var/opt/sqlpackage/sqlpackage \