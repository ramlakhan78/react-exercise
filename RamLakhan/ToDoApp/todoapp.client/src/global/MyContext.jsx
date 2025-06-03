import React, { createContext, useState } from 'react';
import { login } from '../api/AuthApi';


export const Context = createContext();

export const MyContextProvider = ({ children }) => {
    const [accessToken, setAccessToken] = useState(localStorage.getItem('accessToken'));
    //const [refreshTokenValue, setRefreshTokenValue] = useState(localStorage.getItem('refreshToken'));
    const [taskGroups, setTaskGroups] = useState([]);
    const [allGroupTaskList, setAllGroupTaskList] = useState([]);
    const [allStarredTasks, setallStarredTasks] = useState({});
    const [sidebarShow, setSidebarShow] = useState(true);
    const [unfoldable, setUnfoldable] = useState(false);
    const [theme, setTheme] = useState('light');

    const handleLogin = async (username, password) => {
        const res = await login(username, password);
        setAccessToken(res.accessToken);
        //setRefreshTokenValue(res.refreshToken);
        localStorage.setItem('accessToken', res.accessToken);
        //localStorage.setItem('refreshToken', res.refreshToken);
    };

  /*  const handleRefresh = async () => {
        const res = await refreshToken(refreshTokenValue);
        setAccessToken(res.accessToken);
        localStorage.setItem('accessToken', res.accessToken);
    };*/

    return (
        <Context.Provider value={{ theme, setTheme, sidebarShow, setSidebarShow, unfoldable, setUnfoldable, taskGroups, setTaskGroups, allGroupTaskList, setAllGroupTaskList, allStarredTasks, setallStarredTasks, handleLogin, accessToken /*,refreshTokenValue, handleRefresh*/ }}>
            {children}
        </Context.Provider>
    );

}  