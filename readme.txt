docker run -p 3333:3306 --name db -e MYSQL_ROOT_PASSWORD=secret -d mysql:8.0.0

docker ps

dotnet new console -f net6.0 -o MySqlOnFire 

cd MySqlOnFire

dotnet add package MySql.EntityFrameworkCore -v 6.0.0-preview3.1

