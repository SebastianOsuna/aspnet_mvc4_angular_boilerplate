ASP.NET MVC4 - Angular.js Boilerplate
===

This project is a boilerplate codebase for ASP.NET MVC4 projects using Angular as front-end framework.

This boilerplate is intended for SPAs so the ASP code has two sides; Web and an API. The Web part only serves the `index.html` and the assets of the SPA. The API is where the back-end lives.

# Project structure

See the README file in each directory for further details on the code structure.

The front-end code is distributed along several directories.

1. The `index.html` file should be adapted to `cshtml` in order to use the Bundler.
2. The application javascript files should be placed in `Scripts/app`. This can be customized in the `BundleConfig.cs` file.
3. The application javascript dependencied should be placed in `Scripts/vendor`. This can be customized in the `BundleConfig.cs` file.
4. (2) and (3) also apply for stylesheets.
5. Partials, templates and other HTML files should be place under the `static` folder. This can be customized in the `RoutesConfig.cs` using `routes.IgnoreRoute`.

# Example code

This boilerplate comes with a basic Angular application. The application uses [angular-translate](https://github.com/angular-translate/angular-translate) for i18n. The application also has some basic REST authentication functionality.

# Troubleshooting

I had some problems setup up the database with the original `connectionString`. For some reason, EntityFramework was having problems creating the database file. Using [this](http://msdn.microsoft.com/en-us/library/hh510202.aspx) link I created a new database with

```
"C:\Program Files\Microsoft SQL Server\120\Tools\Binn\SqlLocalDB.exe" create LocalDBapp1
"C:\Program Files\Microsoft SQL Server\120\Tools\Binn\SqlLocalDB.exe" start LocalDBapp1
```
*The SqlLocalDB.exe location may vary*

And the pointed the connection to this DB with no file.

*You can change your database connection in `Web.config`*