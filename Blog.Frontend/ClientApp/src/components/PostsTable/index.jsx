import React, { useState, useEffect } from 'react';
import {Link} from 'react-router-dom';
import { Table, Button } from 'reactstrap';
import { CreateApi } from '../../infrastructure/request'
import { IoIosAddCircleOutline, IoMdTrash, IoMdCreate } from "react-icons/io";
import { Loader } from '../Loader';

export const PostsTable = () => {

    const [posts, setPosts] = useState([]);
    const [showLoader, setShowLoader] = useState(true);
    const api = CreateApi('https://localhost:44369/api');

    useEffect(() => {
        api.getPosts()
            .then(data => setPosts(data))
            .catch(reason => console.log(reason))
            .then(() => setShowLoader(false));
    }, []);

    const deletePost = (id) => {
        setShowLoader(true);
        api.deletePost(id)
            .then((response) => {
                setPosts(posts.filter(post => post.id !== id ))
            })
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
                                <Link to={"/edit-post/" + post.id}><IoMdCreate /></Link>
                                <Button color="link" onClick={() => deletePost(post.id)}><IoMdTrash /></Button>
                            </td>
                        </tr>)}
                </tbody>
            </Table>
            <h2><Link to='/add-post'><IoIosAddCircleOutline /></Link></h2>
        </>
    );
}

