using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConestogaCarpoolApplication.Models
{
    public partial class ConestogaCarpoolContext : DbContext
    {
        public ConestogaCarpoolContext()
        {
        }

        public ConestogaCarpoolContext(DbContextOptions<ConestogaCarpoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<ChatRoom> ChatRoom { get; set; }
        public virtual DbSet<ChatRoomStatus> ChatRoomStatus { get; set; }
        public virtual DbSet<Colour> Colour { get; set; }
        public virtual DbSet<LicenceClass> LicenceClass { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<PostStatus> PostStatus { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<RequestStatus> RequestStatus { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<Ride> Ride { get; set; }
        public virtual DbSet<RideStatus> RideStatus { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=ConestogaCarpool;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<ChatRoom>(entity =>
            {
                entity.Property(e => e.ChatRoomId).HasColumnName("chatRoomId");

                entity.Property(e => e.DriverId).HasColumnName("driverId");

                entity.Property(e => e.PassengerId).HasColumnName("passengerId");

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.ChatRoomDriver)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Passenger)
                    .WithMany(p => p.ChatRoomPassenger)
                    .HasForeignKey(d => d.PassengerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.ChatRoom)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChatRoom_ChatRoomStatus");
            });

            modelBuilder.Entity<ChatRoomStatus>(entity =>
            {
                entity.Property(e => e.ChatRoomStatusId).HasColumnName("chatRoomStatusId");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Colour>(entity =>
            {
                entity.Property(e => e.ColourId).HasColumnName("colourId");

                entity.Property(e => e.Colour1)
                    .IsRequired()
                    .HasColumnName("colour")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LicenceClass>(entity =>
            {
                entity.Property(e => e.LicenceClassId).HasColumnName("licenceClassId");

                entity.Property(e => e.LicenceClass1)
                    .IsRequired()
                    .HasColumnName("licenceClass")
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.MessageId).HasColumnName("messageId");

                entity.Property(e => e.ChatRoomId).HasColumnName("chatRoomId");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Message1)
                    .IsRequired()
                    .HasColumnName("message")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.ChatRoom)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.ChatRoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_ChatRoom");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_User");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.PostId).HasColumnName("postId");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasColumnName("destination")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DriverId).HasColumnName("driverId");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnName("location")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Post_User");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Post_PostStatus");
            });

            modelBuilder.Entity<PostStatus>(entity =>
            {
                entity.Property(e => e.PostStatusId).HasColumnName("postStatusId");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.Property(e => e.RequestId).HasColumnName("requestId");

                entity.Property(e => e.PassengerId).HasColumnName("passengerId");

                entity.Property(e => e.PostId).HasColumnName("postId");

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.HasOne(d => d.Passenger)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.PassengerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_User");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_Post");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_RequestStatus");
            });

            modelBuilder.Entity<RequestStatus>(entity =>
            {
                entity.Property(e => e.RequestStatusId).HasColumnName("requestStatusId");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.ReviewId).HasColumnName("reviewId");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasColumnName("comment")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DriverId).HasColumnName("driverId");

                entity.Property(e => e.PassengerId).HasColumnName("passengerId");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.RideId).HasColumnName("rideId");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.ReviewDriver)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Passenger)
                    .WithMany(p => p.ReviewPassenger)
                    .HasForeignKey(d => d.PassengerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Ride)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.RideId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Review_Ride");
            });

            modelBuilder.Entity<Ride>(entity =>
            {
                entity.Property(e => e.RideId).HasColumnName("rideId");

                entity.Property(e => e.PostId).HasColumnName("postId");

                entity.Property(e => e.RequestId).HasColumnName("requestId");

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Ride)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ride_Post");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.Ride)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ride_Request");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Ride)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ride_RideStatus");
            });

            modelBuilder.Entity<RideStatus>(entity =>
            {
                entity.Property(e => e.RideStatusId).HasColumnName("rideStatusId");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Experience).HasColumnName("experience");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasColumnType("image");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LicenceClassId).HasColumnName("licenceClassId");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.LicenceClass)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.LicenceClassId)
                    .HasConstraintName("FK_User_LicenceClass");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.Property(e => e.VehicleId).HasColumnName("vehicleId");

                entity.Property(e => e.ColourId).HasColumnName("colourId");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasColumnType("image");

                entity.Property(e => e.Make)
                    .IsRequired()
                    .HasColumnName("make")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasColumnName("model")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Plate)
                    .IsRequired()
                    .HasColumnName("plate")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.Colour)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.ColourId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_Colour");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_User");
            });
        }
    }
}
