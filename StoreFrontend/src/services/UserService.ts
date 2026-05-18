import type { User } from "../types/responses/User";
import { config  } from "../config";

const API_URL = `${config.api.url}/api/products`;

export async function getUsers(): Promise<User[]> {
    //Significa que la funcion promete devolver una lista de productos.
    try {
        
        const response = await fetch(API_URL);

        if (!response.ok) {
            throw new Error("Error al obtener los usuarios")
        }

        return await response.json();
    } catch (error) {
        console.error("Error en userService: ", error);
        throw error;
    }
}