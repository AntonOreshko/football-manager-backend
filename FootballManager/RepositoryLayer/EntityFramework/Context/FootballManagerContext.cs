using DomainModels.Models;
using DomainModels.Models.BuildingEntities;
using DomainModels.Models.EmployeeEntities;
using DomainModels.Models.PlayerEntities;
using DomainModels.Models.SquadEntities;
using DomainModels.Models.TournamentEntities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.EntityFramework.Context.Configuration;
using RepositoryLayer.EntityFramework.Context.Configuration.BuildingConfigurators;
using RepositoryLayer.EntityFramework.Context.Configuration.EmployeeConfigurators;
using RepositoryLayer.EntityFramework.Context.Configuration.PlayerConfigurators;
using RepositoryLayer.EntityFramework.Context.Configuration.SquadConfigurators;
using RepositoryLayer.EntityFramework.Context.Configuration.TournamentConfigurators;

namespace RepositoryLayer.EntityFramework.Context
{
    public class FootballManagerContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Club> Clubs { get; set; }

        #region Player  Entities

        public DbSet<Player> Players { get; set; }

        public DbSet<PlayerStats> PlayerStats { get; set; }

        public DbSet<PlayerTemporaryStats> PlayerTemporaryStats { get; set; }

        #endregion

        #region Squad  Entities

        public DbSet<Squad> Squads { get; set; }

        public DbSet<FormationPosition> FormationPositions { get; set; }

        #endregion

        #region Building  Entities

        public DbSet<Building> Buildings { get; set; }

        public DbSet<Stadium> Stadiums { get; set; }

        public DbSet<FanClub> FanClubs { get; set; }

        public DbSet<Academy> Academies { get; set; }

        public DbSet<MedicalCenter> MedicalCenters { get; set; }

        public DbSet<TrainingCenter> TrainingCenters { get; set; }

        #endregion

        #region Employee Entities

        public DbSet<Employee> Employees { get; set; }

        public DbSet<HeadCoach> HeadCoaches { get; set; }

        public DbSet<HeadCoachAssistent> HeadCoachAssistents { get; set; }

        public DbSet<Medic> Medics { get; set; }

        public DbSet<Psychologist> Psychologists { get; set; }

        public DbSet<Scout> Scouts { get; set; }

        #endregion

        #region Tournament Entities

        public DbSet<Tournament> Tournaments { get; set; }

        public DbSet<TournamentClub> TpournamentClubs { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<MatchEvent> MatchEvents { get; set; }

        #endregion

        public FootballManagerContext(DbContextOptions<FootballManagerContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfigurator());
            modelBuilder.ApplyConfiguration(new ClubConfigurator());

            modelBuilder.ApplyConfiguration(new BuildingConfigurator());
            modelBuilder.ApplyConfiguration(new AcademyConfigurator());
            modelBuilder.ApplyConfiguration(new FanClubConfigurator());
            modelBuilder.ApplyConfiguration(new MedicalCenterConfigurator());
            modelBuilder.ApplyConfiguration(new StadiumConfigurator());
            modelBuilder.ApplyConfiguration(new TrainingCenterConfigurator());

            modelBuilder.ApplyConfiguration(new EmployeeConfigurator());
            modelBuilder.ApplyConfiguration(new HeadCoachAssistentConfigurator());
            modelBuilder.ApplyConfiguration(new HeadCoachConfigurator());
            modelBuilder.ApplyConfiguration(new MedicConfigurator());
            modelBuilder.ApplyConfiguration(new PsychologistConfigurator());
            modelBuilder.ApplyConfiguration(new ScoutConfigurator());

            modelBuilder.ApplyConfiguration(new PlayerConfigurator());
            modelBuilder.ApplyConfiguration(new PlayerStatsConfigurator());
            modelBuilder.ApplyConfiguration(new PlayerTemporaryStatsConfigurator());

            modelBuilder.ApplyConfiguration(new FormationPositionConfigurator());
            modelBuilder.ApplyConfiguration(new SquadConfigurator());

            modelBuilder.ApplyConfiguration(new MatchConfigurator());
            modelBuilder.ApplyConfiguration(new MatchEventConfigurator());
            modelBuilder.ApplyConfiguration(new TournamentClubConfigurator());
            modelBuilder.ApplyConfiguration(new TournamentConfigurator());
        }
    }
}
