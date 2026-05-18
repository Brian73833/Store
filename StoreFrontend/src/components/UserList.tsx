import { useEffect, useState } from "react";
import type { User } from "../types/responses/User";
import { getUsers } from "../services/UserService";

export function UserList() {
  const [users, setusers] = useState<User[]>([]);

  useEffect(() => {
    getUsers()
      .then((data) => {
        setusers(data);
      })
      .catch((error) => {
        console.error("Error al obtener usuarios: ", error);
      });
  }, []);

  return (
    <div>
      <h1>Lista de Usuarios</h1>
      {users.map((user) => (
        <div key={user.externalId}>
          <p>{user.name}</p>
          <p>{user.username}</p>
          <p>{user.email}</p>
        </div>
      ))}
    </div>
  );
}
