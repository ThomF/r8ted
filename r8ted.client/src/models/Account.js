export class Account {
  constructor(data) {
    this.id = data.id
    this.email = data.email
    this.name = data.name
    this.picture = data.picture
    this.coverImg = data.banner
    // TODO add additional properties if needed
    this.verified = data.verified
    this.createdAt = data.created_at
  }
}
