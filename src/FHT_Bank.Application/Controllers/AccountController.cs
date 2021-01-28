using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FHT_Bank.Domain.Dtos;
using FHT_Bank.Domain.Interfaces;
using FHT_Bank.Domain.Models;
using FHT_Bank.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace FHT_Bank.Application.Controllers
{
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] WithdrawDto withdrawDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.Select(x => x.Errors.Select(e => e.ErrorMessage)));

            return Ok(await _accountService.Withdraw(withdrawDto));
        }

        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit([FromBody] DepositDto depositDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.Select(x => x.Errors.Select(e => e.ErrorMessage)));

            return Ok(await _accountService.Deposit(depositDto));
        }

        [HttpGet("{accountId}")]
        public async Task<IActionResult> Balance([FromRoute] int accountId)
        {
            if (!await _accountService.Exists(accountId))
                return NotFound("Conta inválida");

            return Ok(await _accountService.Balance(accountId));
        }
    }
}