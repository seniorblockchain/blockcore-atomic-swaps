﻿using Blazored.LocalStorage;
using Blockcore.AtomicSwaps.Server.Controllers;

namespace Blockcore.AtomicSwaps.Client
{
    public class Storage
    {
        private readonly ISyncLocalStorageService _storage;

        public Storage(ISyncLocalStorageService storage)
        {
            _storage = storage;
        }
        public void SaveWalletWords(string mnemonic)
        {
            _storage.SetItemAsString("mnemonic", mnemonic);
        }

        public string GetWalletWords()
        {
            return _storage.GetItemAsString("mnemonic");
        }

        public AccountInfo GetAccountInfo(string network)
        {
            return _storage.GetItem<AccountInfo>($"utxo:{network}");
        }

        public void SetAccountInfo(string network, AccountInfo items)
        {
            _storage.SetItem($"utxo:{network}", items);
        }
    }
}