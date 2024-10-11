# Windows Server CPU Stress

This ASP.NET repository contains two HTML pages to process prime number up to a given input by an user.

## Requirements

- Windows Server
- World Wide Web, IIS and Aplication roles (Server Manager)
- .NET 8.0+ Core Host Bundle installed

## Main files

### Controller
HomeController.cs carries two function:

1. IsPrime()
```C#
/// <summary>
/// Check if a number is prime.
/// </summary>
/// <param name="num">The number to check.</param>
/// <returns>True if the number is prime, false otherwise.</returns>
/// <remarks>
/// This method is not efficient, but it is simple and easy to understand.
/// It checks if the number is divisible by any number from 2 to the square root of the number.
/// If it is divisible by any of these numbers, then it is not prime.
/// If it is not divisible by any of these numbers, then it is prime.
/// </remarks>
private bool IsPrime(int num)
{
    if (num < 2) return false;
    for (int i = 2; i <= Math.Sqrt(num); i++)
    {
        if (num % i == 0) return false;
    }
    return true;
}
```   

2. GetPrimesUpTo() - which calls IsPrime()
```C#
/// <summary>
/// Get all prime numbers up to a given number.
/// </summary>
/// <param name="max">The maximum number to check.</param>
/// <returns>A list of all prime numbers up to the input.</returns>
/// <remarks>
/// This method is not efficient, but it is simple and easy to understand.
/// It checks if each number is prime using the IsPrime method.
/// If the number is prime, it is added to the list of primes.
/// Finally, the list of primes is returned.
/// </remarks>
private List<int> GetPrimesUpTo(int max)
{
    var primes = new List<int>();
    for (int num = 2; num <= max; num++)
    {
        if (IsPrime(num))
        {
            primes.Add(num);
        }
    }
    return primes;
}
```

### Views/Home

#### Index.cshtml
Presents a form so the user can input a upper limit (a maximum) for the List<int> of primes as the result.

#### Results.cshtml
Displays each of the elements (primes) in a new line up to the input of the Index.cshtml page.

Also provides a back button.

### Program.cs
The only change made was:

```C#
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
```

## Publish to IIS on Windows Server

### Preparing the project
1. Build
I personally suggest `C:\Projects\win-server-cpu-stress` as the webapp directory.
```bash
dotnet build <webapp-directory>
```

2. Publish

Choose a local publish. That may be `C:\Published\win-server-cpu-stress`

```bash
dotnet publish -c Release -o <output-directory>
```

### Running on IIS

1. Add a new Website

With IIS open, right click on Sites ...

![image](https://github.com/user-attachments/assets/5f9f389f-206a-42b1-8ef5-daac5a7ab36b)

2. Set it up

Set a name such as `win-server-cpu-stress`

- If it's a new site, IIS might create a new `Application pool` (field to the right of the name) which will follow with the same name as you choose for your `Site name`. 

- Choose the path for the published webapp such as `C:\Published\win-server-cpu-stress`.

- Bind a port such as 80. Make sure there are rules to allow traffic from that port on Windows Defender Firewall's Ibound Rules. Added them as needed.

![image-1](https://github.com/user-attachments/assets/278b4997-fb20-466f-8ca6-15e94b01fa27)

3. Check its Application pool

(LEFT) Click on Application Pools;

(MIDDLE) Click on the name of your pool such as `win-server-cpu-stress`;

(RIGHT) Click on `Basic settings`.

![image-2](https://github.com/user-attachments/assets/66b763b2-3e4e-4c53-870b-1b94683cd9b4)

And finally make sure your pool's `.NET CLR version` is set to `No Managed Code`

![image-3](https://github.com/user-attachments/assets/8a6695e7-ef4d-4d4e-9bca-1687423e058e)

## The webapp

### Index.cshtml
![image-4](https://github.com/user-attachments/assets/b118b4fd-71a9-4ee4-8865-121289586bb2)

### Results.cshtml
![image-5](https://github.com/user-attachments/assets/21508fad-34c4-4566-8315-9a997c525b37)

