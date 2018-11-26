db.createUser({
    user: 'Phu',
    pwd: '123',
    roles: [{ role: 'readWrite', db:'LearningMongoDB'}]
})