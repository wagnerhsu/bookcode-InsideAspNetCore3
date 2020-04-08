<Query Kind="Program">
  <Namespace>Microsoft.Extensions.Configuration</Namespace>
  <Namespace>Microsoft.Extensions.DependencyInjection</Namespace>
  <Namespace>Microsoft.Extensions.Options</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

void Main()
{
	var dir = Path.GetDirectoryName(Util.CurrentQueryPath);
	var configuration = new ConfigurationBuilder()
		.AddJsonFile(Path.Combine(dir,"profile.json"))
		.Build();
	var profile = new ServiceCollection()
		.AddOptions()
		.Configure<Profile>(configuration)
		.BuildServiceProvider()
		.GetRequiredService<IOptions<Profile>>()
		.Value;
	profile.Dump();
}

// Define other methods, classes and namespaces here
public class Profile
{
	public Gender Gender { get; set; }
	public int Age { get; set; }
	public ContactInfo ContactInfo { get; set; }
}

public class ContactInfo
{
	public string EmailAddress { get; set; }
	public string PhoneNo { get; set; }
}

public enum Gender
{
	Male,
	Female
}