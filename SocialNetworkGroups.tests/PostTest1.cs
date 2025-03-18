namespace SocialNetworkGroups.tests;

        /// <summary>
        /// Класс с юнит-тестами репозитория записей пользователей
        /// </summary>
        public class UserPostRepositoryTests
        {
            /// <summary>
            /// Параметризованный тест метода, возвращающего топ 5 пользователей по количеству созданных записей за указанный период
            /// </summary>
            /// <param name="startDate"></param>
            /// <param name="endDate"></param>
            /// <param name="expectedCount"></param>
            [Theory]
            [InlineData("2023-01-01", "2023-12-31", 3)] // Примерные даты и ожидаемое количество
            [InlineData("2023-01-01", "2023-01-10", 1)]
            [InlineData("2023-02-01", "2023-02-28", 1)]
            public async Task GetTop5UsersByPostCount_Success(string startDate, string endDate, int expectedCount)
            {
                // Arrange
                var repo = new UserPostInMemoryRepository();
                var start = DateTime.Parse(startDate);
                var end = DateTime.Parse(endDate);

                // Act
                var topUsers = await repo.GetTop5UsersByPostCount(start, end);

                // Assert
                Assert.Equal(expectedCount, topUsers.Count);
            }
        }
