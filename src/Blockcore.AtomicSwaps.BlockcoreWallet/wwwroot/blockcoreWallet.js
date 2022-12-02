import { BlockcoreDns } from './_snowpack/pkg/@blockcore/dns.js';
import { WebProvider } from './_snowpack/pkg/@blockcore/provider.js';

export async function hasBlockcoreWallet() {
    return (globalThis.blockcore != undefined);
}

export async function signMessage(msg) {
    const provider = await WebProvider.Create();
    let signature;
    try {
        signature = await provider.request({ method: "signMessage", params: [{ scheme: "schnorr", message: msg }] });
        return JSON.stringify(signature);
    }
    catch (error) {
        console.error("Error: " + error.message);
        // User denied account access...
        throw "UserDenied";
    }
}

