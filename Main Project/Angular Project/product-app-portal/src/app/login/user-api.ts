export class UserApi {
  constructor(
    public email: string,
    public id: string,
    private _token: string,
    private _tokenExpirationDate: string
  ) { }

  get token() {
    if (!this._tokenExpirationDate || new Date() > new Date(this._tokenExpirationDate)) {
      return null;
    }
    return this._token;
  }
}

