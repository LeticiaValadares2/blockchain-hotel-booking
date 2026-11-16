
import json
from pathlib import Path
from web3 import Web3

# Connect to Ganache
w3 = Web3(Web3.HTTPProvider("http://127.0.0.1:8545"))

if not w3.is_connected():
    raise ConnectionError("Cannot connect to Ganache")

print("Connected to Ganache!")

# Hotel owner account
hotel_owner = w3.eth.accounts[0]
w3.eth.default_account = hotel_owner

# Find compiled contract
project = Path(__file__).resolve().parent.parent
build = project / "build"

abi_files = list(build.glob("*HotelBooking.abi"))
bin_files = list(build.glob("*HotelBooking.bin"))

if len(abi_files) != 1 or len(bin_files) != 1:
    raise FileNotFoundError(
        "Contract not compiled. Check build folder."
    )

abi = json.loads(abi_files[0].read_text())
bytecode = bin_files[0].read_text().strip()

# Deploy contract
contract = w3.eth.contract(
    abi=abi,
    bytecode=bytecode
)

tx_hash = contract.constructor().transact({
    "from": hotel_owner
})

receipt = w3.eth.wait_for_transaction_receipt(tx_hash)

if receipt.status != 1:
    raise RuntimeError("Deployment failed")

print("Contract deployed successfully!")
print("Contract address:", receipt.contractAddress)

# Save deployment information
deployment = {
    "address": receipt.contractAddress,
    "abi": abi
}

(build / "deployment.json").write_text(
    json.dumps(deployment, indent=2)
)

print("Deployment information saved!")
