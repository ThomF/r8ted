export class Review {
    constructor(data) {
        this.id = data.id
        this.userId = data.user_id
        this.movieId = data.movie_id
        this.title = data.title
        this.description = data.description
        this.likes = data.likes
        this.catOne = data.catOne
        this.catTwo = data.catTwo
        this.isPrivate = data.isPrivate
        this.joshRated = data.joshRated

    }
}