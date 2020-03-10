import React, { useState, useEffect } from 'react';
import { Table, Button } from 'reactstrap';
import { GetData, DeleteData } from '../../infrastructure/request'
import { IoIosAddCircleOutline, IoMdTrash, IoMdCreate } from "react-icons/io";
import { Loader } from '../Loader';

export const PostsTable = () => {

    const [posts, setPosts] = useState([]);
    const [showLoader, setShowLoader] = useState(true);

    useEffect(() => {
        const posts = GetData('https://localhost:44369/api/posts')
            .then(data => setPosts(data))
            .catch(reason => console.log(reason))
            .then(() => setShowLoader(false));
    });

    const deletePost = (id) => {
        setShowLoader(true);
        DeleteData('https://localhost:44369/api/posts/' + id)
            .then((response) => console.log(response))
            .catch(error => console.log(error))
            .then(() => setShowLoader(false));
    }

    return (
        <>
            {showLoader && <Loader />}
            <Table hover>
                <thead>
                    <tr>
                        <th>Title</th>
                        <th>Status</th>
                        <th>Author</th>
                        <th>Created</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {posts.map(post =>
                        <tr key={post.id}>
                            <td>{post.title}</td>
                            <td>{post.status}</td>
                            <td>{post.author}</td>
                            <td>{post.created}</td>
                            <td>
                                <a href={"/edit-post/" + post.id}><IoMdCreate /></a>
                                <Button color="link" onClick={() => deletePost(post.id)}><IoMdTrash /></Button>
                            </td>
                        </tr>)}
                </tbody>
            </Table>
            <h2><a href="/add-post"><IoIosAddCircleOutline /></a></h2>
        </>
    );
}

