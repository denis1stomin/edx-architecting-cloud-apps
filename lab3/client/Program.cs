using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Queue;

namespace client
{
	class Program
	{
		static void Main(string[] args)
		{
            var accountName = Environment.GetEnvironmentVariable("AZURE_STORAGE_ACCOUNT");
            var accountKey = Environment.GetEnvironmentVariable("AZURE_STORAGE_KEY");

			var storageAccount = new CloudStorageAccount(
                new StorageCredentials(accountName, accountKey), true);

			var queueClient = storageAccount.CreateCloudQueueClient();

        	var queue = queueClient.GetQueueReference("jobqueue");

        	queue.CreateIfNotExistsAsync().GetAwaiter().GetResult();

        	var message = new CloudQueueMessage(GetMessage(args));

        	queue.AddMessageAsync(message).GetAwaiter().GetResult();

    	}

   		private static string GetMessage(string[] args)
   		{
       	    return ((args.Length > 0) ? string.Join(" ", args) : "Hello World!");
   		}
	}
}
