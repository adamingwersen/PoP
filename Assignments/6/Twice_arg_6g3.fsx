    | Twice (m, (int1, int2)) ->
        match (colorAt (x, y) m, colorAt ((x-int1), (y-int2)) m) with
        | (c, None) -> c
        | (None, c) -> c
        | (b, c) -> c