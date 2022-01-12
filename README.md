# TimeWatch
```
/src
*ApplicationCore 
*Infrastructure 
*Web 
*UnitTests

/tests
*UnitTests
```

### Packages
```
/ApplicationCore
Install-Package Ardalis.Specification

/Infrastructure
Install-Package Microsoft.EntityFrameworkCore -v 5.0.13
Install-Package Ardalis.Specification.EntityFrameworkCore
Install-Package Npgsql.EntityFrameworkCore.PostgreSQL -v 5.0.10
Install-Package Microsoft.AspNetCore.Identity.EntityFrameworkCore -v 5.0.13

/Web
Install-Package Npgsql.EntityFrameworkCore.PostgreSQL -v 5.0.10
Install-Package Microsoft.EntityFrameworkCore.Tools -v 5.0.13
Install-Package Npgsql.EntityFrameworkCore.PostgreSQL -v 5.0.10
```

### Migrations
```
/Infrastructure
Add-Migration InitialCreate -c MarketContext -s Web -o Data/Migrations
Update-Database -Context MarketContext -s Web
Add-Migration InitialIdentity -c AppIdentityDbContext -s Web -o Identity/Migrations
Update-Database -Context AppIdentityDbContext -s Web
```

### Resources
* https://github.com/dotnet-architecture/eShopOnWeb
* https://www.postgresql.org/
* https://www.npgsql.org/doc/types/basic.html
* https://www.npgsql.org/efcore/
* https://getbootstrap.com/docs/4.6/components/card/#example
* https://stackoverflow.com/questions/5269713/css-ellipsis-on-second-line
* https://getbootstrap.com/docs/4.6/components/pagination/#alignment
* https://gist.github.com/yigith/c6f999788b833dc3d22ac6332a053dd1
