module App.Nav {
    
    export interface INavScope {
        title: string;
        login(): void;
        logout(): void;
        userIsLoggedIn: boolean;
    }
}