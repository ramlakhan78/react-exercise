const BASE_URL = '/api/Auth';

export const login = async (username, password) => {
    const res = await fetch(`${BASE_URL}/login`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ username, password })
    });

    return res.json();
}

/*export const refreshToken = async(refreshToken) => {
    const res = await fetch(`${BASE_URL}/refresh`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ refreshToken })
    });

    return res.json();
}*/

export const logout = () => {
    localStorage.removeItem('token');
}