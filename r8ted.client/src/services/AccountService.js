import { AppState } from '../AppState'
import { Account } from '../models/Account.js'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      // debugger
      const res = await api.get('/account')

      AppState.account = new Account(res.data)
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async editAccount(edits) {
    logger.log('edit data', edits)
    const res = await api.put('account', edits)
    AppState.account = res.data
  }

}

export const accountService = new AccountService()
