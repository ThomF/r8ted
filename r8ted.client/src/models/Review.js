export class Review {
    constructor(data) {
        this.id = data.id
        this.userId = data.user_id
        // NOTE ADD MORE CREATOR INFO IF NEEDED HERE TO GET INFO PER REVIEW CARD
        this.userImg = data.creator.picture
        this.userName = data.creator.name
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