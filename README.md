# Web contact form to RPM via API

Code example for a website that lets visitor fill and send a simple contact form to a process in RPM.

## Setting up this example

1. Create the target process by importing `Contact.xml` into RPM
2. Open `Web2Rpm.sln` in Visual Studio
2. Configure the [API key](https://api.rpmsoftware.com/getting-started/#keys), ProcessID and (optional) the [API URL](https://api.rpmsoftware.com/getting-started/#url) in [HomeController.cs](https://github.com/rpmsoftware/Web2Rpm/blob/master/Web2Rpm/Controllers/HomeController.cs#L14)

## API documentation

For more in depth information about RPM's API, visit our documentation at [api.rpmsoftware.com](https://api.rpmsoftware.com/)