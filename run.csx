using System;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;

public static async Task Run(TimerInfo myTimer, TraceWriter log)
{
    log.Info($"C# Timer trigger function executed at: {DateTime.Now}");

    AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider();

    var keyVaultClient = new KeyVaultClient(
                    new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));

    var secret = await keyVaultClient.GetSecretAsync(URL_TO_KEYVAULT_SECRET)
                    .ConfigureAwait(false);

    log.Info($"C# Timer trigger function retrieved secret value: {secret.Value}");
}
