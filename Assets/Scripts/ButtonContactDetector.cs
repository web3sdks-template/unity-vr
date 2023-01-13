using Web3sdks;
using UnityEngine;

public class ButtonContactDetector : MonoBehaviour
{
    private Web3sdksSDK sdk;

    void Start()
    {
        sdk = new Web3sdksSDK("optimism-goerli");
    }

    // When the box collider comes into contact with the hands
    private async void OnTriggerEnter(Collider other)
    {
        if (Application.isEditor)
        {
            Debug
                .Log("Connect Wallet not supported in Editor. Build and run on device.");
            return;
        }

        // If the tag is player
        if (other.gameObject.tag == "Player")
        {
            string address =
                await sdk
                    .wallet
                    .Connect(new WalletConnection()
                    {
                        provider = WalletProvider.CoinbaseWallet,
                        chainId = 420 // Switch the wallet Goerli on connection
                    });
        }
    }
}
