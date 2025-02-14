# Example: Managing Virtual Machines

--------------------------------------
For this example, you need the following namespaces:

```C# Snippet:Managing_VirtualMachines_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
```

When you first create your ARM client, choose the subscription you're going to work in. There's a convenient `DefaultSubscription` property that returns the default subscription configured for your user:

```C# Snippet:Readme_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via container objects. Or you can access individual children by ID.

```C# Snippet:Readme_GetResourceGroupContainer
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
ResourceGroupContainer rgContainer = subscription.GetResourceGroups();
// With the container, we can create a new resource group with an specific name
string rgName = "myRgName";
Location location = Location.WestUS2;
ResourceGroupCreateOrUpdateOperation lro = await rgContainer.CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
ResourceGroup resourceGroup = lro.Value;
```

Now that we have the resource group created, we can manage the virtual machines inside this resource group.

Please notice that before we create a virtual machine, at lease we need to create a Network Interface resource as prerequisite. Please refer to documentation of `Azure.ResourceManager.Network` for details of creating a Network Interface.

***Create a virtual machine***

```C# Snippet:Managing_VirtualMachines_CreateAVirtualMachine
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
// first we need to get the resource group
string rgName = "myRgName";
ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
// Now we get the virtual machine container from the resource group
VirtualMachineContainer vmContainer = resourceGroup.GetVirtualMachines();
// Use the same location as the resource group
string vmName = "myVM";
var input = new VirtualMachineData(resourceGroup.Data.Location)
{
    HardwareProfile = new HardwareProfile()
    {
        VmSize = VirtualMachineSizeTypes.StandardF2
    },
    OsProfile = new OSProfile()
    {
        AdminUsername = "adminUser",
        ComputerName = "myVM",
        LinuxConfiguration = new LinuxConfiguration()
        {
            DisablePasswordAuthentication = true,
            Ssh = new SshConfiguration()
            {
                PublicKeys = {
        new SshPublicKeyInfo()
        {
            Path = $"/home/adminUser/.ssh/authorized_keys",
            KeyData = "<value of the public ssh key>",
        }
    }
            }
        }
    },
    NetworkProfile = new NetworkProfile()
    {
        NetworkInterfaces =
        {
            new NetworkInterfaceReference()
            {
                Id = "/subscriptions/<subscriptionId>/resourceGroups/<rgName>/providers/Microsoft.Network/networkInterfaces/<nicName>",
                Primary = true,
            }
        }
    },
    StorageProfile = new StorageProfile()
    {
        OsDisk = new OSDisk(DiskCreateOptionTypes.FromImage)
        {
            OsType = OperatingSystemTypes.Linux,
            Caching = CachingTypes.ReadWrite,
            ManagedDisk = new ManagedDiskParameters()
            {
                StorageAccountType = StorageAccountTypes.StandardLRS
            }
        },
        ImageReference = new ImageReference()
        {
            Publisher = "Canonical",
            Offer = "UbuntuServer",
            Sku = "16.04-LTS",
            Version = "latest",
        }
    }
};
VirtualMachineCreateOrUpdateOperation lro = await vmContainer.CreateOrUpdateAsync(vmName, input);
VirtualMachine vm = lro.Value;
```

***List all virtual machines***

```C# Snippet:Managing_VirtualMachines_ListAllVirtualMachines
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
// first we need to get the resource group
string rgName = "myRgName";
ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
// Now we get the virtual machine container from the resource group
VirtualMachineContainer vmContainer = resourceGroup.GetVirtualMachines();
// With ListAsync(), we can get a list of the virtual machines in the container
AsyncPageable<VirtualMachine> response = vmContainer.GetAllAsync();
await foreach (VirtualMachine vm in response)
{
    Console.WriteLine(vm.Data.Name);
}
```

***Delete a virtual machine***

```C# Snippet:Managing_VirtualMachines_DeleteVirtualMachine
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
// first we need to get the resource group
string rgName = "myRgName";
ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
// Now we get the virtual machine container from the resource group
VirtualMachineContainer vmContainer = resourceGroup.GetVirtualMachines();
string vmName = "myVM";
VirtualMachine vm = await vmContainer.GetAsync(vmName);
await vm.DeleteAsync();
```
