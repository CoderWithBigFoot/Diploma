﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShareYourself.Data.Contexts;
using ShareYourself.Data.Entities;

namespace ShareYourself.Data.Test
{
    [TestClass]
    public class EntitiesTests
    {
        [TestMethod]
        public void FullInfoPostCreatingDeleting_Successful()
        {
            ShareYourselfContext context = new ShareYourselfContext("ShareYourself");

            UserProfile profile_1 = new UserProfile
            {
                RegistrationDate = DateTime.Now,
                Name = "For test name",
                Surname = "For test surname"
            };

            UserPost post_1 = new UserPost
            {
                Content = "Some content",
                Creator = profile_1
            };

            Tag tag_1 = new Tag
            {
                Name = "Some test tag"
            };

            post_1.Tags.Add(tag_1);


            try
            {
                context.Set<UserPost>()
                    .Add(post_1);
                context.SaveChanges();

                context.Set<UserPost>()
                    .Remove(post_1);

                context.Set<Tag>()
                    .Remove(tag_1);

                context.Set<UserProfile>()
                    .Remove(profile_1);

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void TagsCreatingDeleting_Successful()
        {
            ShareYourselfContext context = new ShareYourselfContext("ShareYourself");

            Tag tag = new Tag
            {
                Name = "Some test tag"
            };

            try
            {
                var set = context.Set<Tag>();

                set.Add(tag);
                context.SaveChanges();

                set.Remove(tag);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void LikesAddRemove_Success()
        {
            ShareYourselfContext context = new ShareYourselfContext("ShareYourself");

            UserProfile user_1 = new UserProfile
            {
                Name = "test",
                Surname = "test",
                RegistrationDate = DateTime.Now
            };

            UserPost post_1 = new UserPost
            {
                Content = "test content",
                CreationDate = DateTime.Now,
                Creator = user_1
            };

            post_1.Likes.Add(user_1);

            try
            {
                var posts = context.Set<UserPost>();
                var users = context.Set<UserProfile>();

                context.Set<UserPost>().Add(post_1);
                user_1.Likes.Remove(post_1);

                posts.Remove(post_1);
                users.Remove(user_1);
                
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void SubscriptionsAddRemove_Success()
        {
            ShareYourselfContext context = new ShareYourselfContext("ShareYourself");

            UserProfile user_1 = new UserProfile
            {
                Name = "test_1",
                Surname = "test_1",
                RegistrationDate = DateTime.Now
            };

            UserProfile user_2 = new UserProfile
            {
                Name = "test_2",
                Surname = "test_2",
                RegistrationDate = DateTime.Now
            };

            try
            {
                var userSet = context.Set<UserProfile>();

                user_1.Subscriptions.Add(user_2);
                user_2.Subscriptions.Add(user_1);
                userSet.Add(user_1);

                context.SaveChanges();

                user_1.Subscriptions.Remove(user_2);
                user_2.Subscriptions.Remove(user_1);
                userSet.Remove(user_1);
                userSet.Remove(user_2);

                context.SaveChanges();
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
