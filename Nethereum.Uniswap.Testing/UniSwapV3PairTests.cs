using System;
using System.Numerics;
using Nethereum.Signer;
using Nethereum.Util;
using Nethereum.Web3.Accounts;
using Nethereum.XUnitEthereumClients;
using Xunit;
using Nethereum.Web3;
using Nethereum.Contracts;
using Nethereum.RPC.Eth.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using Nethereum.BlockchainProcessing.ProgressRepositories;
using Nethereum.Uniswap.Contracts.UniswapV2Factory;
using Nethereum.Uniswap.Contracts.UniswapV2Pair;
using Nethereum.Uniswap.Contracts.UniswapV2Pair.ContractDefinition;
using Nethereum.Uniswap.Contracts.UniswapV2Router01.ContractDefinition;
using Nethereum.Uniswap.Contracts.UniswapV2Router02;
using Nethereum.Uniswap.Contracts.UniswapV2Router02.ContractDefinition;
using Nethereum.Uniswap.Contracts.UniswapV3Pool;

namespace Nethereum.Uniswap.Testing
{
    [Collection(EthereumClientIntegrationFixture.ETHEREUM_CLIENT_COLLECTION_DEFAULT)]
    public class UniSwapV3PairTests
    {
        private readonly EthereumClientIntegrationFixture _ethereumClientIntegrationFixture;

        public UniSwapV3PairTests(EthereumClientIntegrationFixture ethereumClientIntegrationFixture)
        {
            _ethereumClientIntegrationFixture = ethereumClientIntegrationFixture;
        }

        [Fact]
        public async void ShouldPositionPairForMaticWeth()
        {
            var web3 = new Web3.Web3(EthereumClientIntegrationFixture.GetAccount(), "https://matic-mumbai.chainstacklabs.com");
            var factoryAddress = "0xC36442b4a4522E871399CD717aBDD847Ab11FE88";
            var uniswapV3PoolService = new UniswapV3PoolService(web3, factoryAddress);
            var weth = "0xA6FA4fB5f76172d178d61B04b0ecd319C5d1C0aa";
            var matic = "0x9c3C9283D3e44854697Cd22D3Faa240Cfb032889";
            var pair = await uniswapV3PoolService.PositionsQueryAsync(
                new Nethereum.Uniswap.Contracts.UniswapV3Pool.ContractDefinition.PositionsFunction() { TokenId = 3906 }
            );
            Assert.True(pair.Token0.ToUpper() == matic.ToUpper() && pair.Token1.ToUpper() == weth.ToUpper());
        }

    }
}